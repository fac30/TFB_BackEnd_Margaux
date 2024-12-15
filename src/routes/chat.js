const express = require('express');
const router = express.Router();
const OpenAI = require('openai');

const openai = new OpenAI({
    apiKey: process.env.OPENAI_API_KEY
});

router.post('/chat', async (req, res) => {
    try {
        const { message } = req.body;

        console.log('Sending request to OpenAI with message:', message);
        const completion = await openai.chat.completions.create({
            model: "gpt-3.5-turbo",
            messages: [{ role: "user", content: message }],
            temperature: 0.7,
        });
        console.log('Received response from OpenAI:', completion);

        res.json({
            success: true,
            response: completion.choices[0].message.content
        });
    } catch (error) {
        console.error('Error in chat route:', error);
        res.status(500).json({
            success: false,
            error: 'An error occurred while processing the request'
        });
    }
});

module.exports = router; 