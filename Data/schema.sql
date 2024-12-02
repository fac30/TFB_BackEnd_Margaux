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

CREATE TABLE users (
    user_id SERIAL PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    theme VARCHAR(50) NOT NULL
);

CREATE TABLE categories (
    category_id SERIAL PRIMARY KEY,
    category_name VARCHAR(255) NOT NULL,
    default_name VARCHAR(255) NOT NULL,
    colour VARCHAR(50),
    region VARCHAR(100)
);

CREATE TABLE clothing_items (
    item_id SERIAL PRIMARY KEY,
    user_id INT NOT NULL,
    category_id INT NOT NULL,
    item_desc VARCHAR(255) NOT NULL,
    photo_id INT,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

