CREATE TABLE outfits (
    outfit_id SERIAL PRIMARY KEY,
    user_id INT NOT NULL,
    outfit_name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
