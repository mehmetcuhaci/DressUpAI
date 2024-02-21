async function callAPIAndDisplayResponse() {
    const url = 'https://api.together.xyz/v1/chat/completions';
    const apiKey = 'TOGETHER_API_KEY';

    const headers = new Headers({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${apiKey}`
    });

    const data = {
        model: 'mistralai/Mixtral-8x7B-Instruct-v0.1',
        max_tokens: 1024,
        messages: [
            {
                role: 'system',
                content: 'You are an AI assistant'
            },
            {
                role: 'user',
                content: 'Who won the world series in 2020?'
            }
        ]
    };

    const options = {
        method: 'POST',
        headers,
        body: JSON.stringify(data)
    };

    try {
        const response = await fetch(url, options);
        const result = await response.json();
        // Gelen cevab� ekrana yazd�r
        console.log(result);
        // E�er gelen cevab� HTML sayfas�nda g�stermek istiyorsan�z, a�a��daki sat�r� kullanabilirsiniz:
        // document.getElementById("response").innerText = JSON.stringify(result, null, 2);
    } catch (error) {
        console.error('Error:', error);
    }
}
callAPIAndDisplayResponse();