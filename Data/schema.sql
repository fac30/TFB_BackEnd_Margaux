CREATE TABLE outfits (
    outfit_id SERIAL PRIMARY KEY,
    user_id INT NOT NULL,
    outfit_name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE out_items (
    outfit_id INT NOT NULL,
    item_id INT NOT NULL,
    added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (outfit_id) REFERENCES outfits(outfit_id)
);

