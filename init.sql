CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE Rating (
                        Rating_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                        User_id UUID NOT NULL,
                        Average_rating DECIMAL(3, 2) DEFAULT 0.0,
                        Count_5_stars INTEGER DEFAULT 0,
                        Count_4_stars INTEGER DEFAULT 0,
                        Count_3_stars INTEGER DEFAULT 0,
                        Count_2_stars INTEGER DEFAULT 0,
                        Count_1_star INTEGER DEFAULT 0
);

CREATE TABLE Review (
                        Review_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                        Review_text TEXT,
                        Job_id UUID NOT NULL,
                        Reviewer_client_id UUID NOT NULL,
                        Reviewed_worker_id UUID NOT NULL,
                        Rating_score INTEGER CHECK (Rating_score BETWEEN 1 AND 5),
                        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (Reviewer_client_id) REFERENCES Rating(User_id) ON DELETE CASCADE,
                        FOREIGN KEY (Reviewed_worker_id) REFERENCES Rating(User_id) ON DELETE CASCADE
);

CREATE TABLE Image (
                       Image_id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                       Review_id UUID NOT NULL REFERENCES Review(Review_id) ON DELETE CASCADE,
                       Image_url VARCHAR(255) NOT NULL,
                       Uploaded_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
