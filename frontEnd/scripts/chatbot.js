document.getElementById("open-chatbot").addEventListener("click", () => {
    document.getElementById("chatbot").style.display = "flex";
    document.getElementById("open-chatbot").style.display = "none";
});

document.getElementById("close-chatbot").addEventListener("click", () => {
    document.getElementById("chatbot").style.display = "none";
    document.getElementById("open-chatbot").style.display = "block";
});

document.getElementById("send-message").addEventListener("click", sendMessage);
document.getElementById("chatbot-input").addEventListener("keypress", function (e) {
    if (e.key === "Enter") {
        sendMessage();
    }
});

function sendMessage() {
    const inputField = document.getElementById("chatbot-input");
    const userMessage = inputField.value.trim();

    if (userMessage === "") return;

    // Adiciona a mensagem do usuário
    appendMessage(userMessage, "user-message");

    // Limpa o campo de entrada
    inputField.value = "";

    // Gera uma resposta automática
    setTimeout(() => {
        const botResponse = generateResponse(userMessage);
        appendMessage(botResponse, "bot-message");
    }, 1000);
}

function appendMessage(message, className) {
    const messageDiv = document.createElement("div");
    messageDiv.className = className;
    messageDiv.textContent = message;
    document.getElementById("chatbot-messages").appendChild(messageDiv);

    // Scroll automático para a mensagem mais recente
    const messagesDiv = document.getElementById("chatbot-messages");
    messagesDiv.scrollTop = messagesDiv.scrollHeight;
}

function generateResponse(message) {
    // Respostas simples baseadas em palavras-chave
    message = message.toLowerCase();

    if (message.includes("olá") || message.includes("oi")) {
        return "Olá! Em que posso ajudá-lo?";
    } else if (message.includes("reserva")) {
        return "Você gostaria de fazer uma reserva? Por favor, informe a data e o tipo de quarto.";
    } else if (message.includes("preço") || message.includes("custo")) {
        return "Nossos preços variam de acordo com o quarto e a temporada. Consulte nossa página de reseva!";
    } else {
        return "Desculpe, não entendi sua pergunta. Por favor entre em contato conosco! ";
    }
}
