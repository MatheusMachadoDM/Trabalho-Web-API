document.addEventListener("DOMContentLoaded", function() {
    const checkinInput = document.getElementById("checkin");
    const checkoutInput = document.getElementById("checkout");
    const adultosInput = document.getElementById("adultos");
    const quartosInput = document.getElementById("quartos");


    // Define a data mínima para o check-in como o dia atual
    const today = new Date().toISOString().split("T")[0];
    checkinInput.min = today;

    // Atualiza a data mínima de check-out com base no check-in selecionado
    checkinInput.addEventListener("change", function() {
        checkoutInput.min = checkinInput.value;
    });

    adultosInput.addEventListener("input", function() {
        quartosInput.max = adultosInput.value; // Atualiza o max de quartos
        if (quartosInput.value > adultosInput.value) {
            quartosInput.value = adultosInput.value; // Ajusta se o valor atual for maior
        }
    });

    // Toggle do dropdown
    const dropdownButton = document.querySelector(".dropdown button");
    const dropdownContent = document.querySelector(".dropdown-content");

    dropdownButton.addEventListener("click", function(event) {
        event.stopPropagation(); // Impede o clique de fechar o dropdown
        dropdownContent.style.display = dropdownContent.style.display === "block" ? "none" : "block";
    });

    // Fecha o dropdown se o usuário clicar fora dele
    document.addEventListener("click", function() {
        dropdownContent.style.display = "none";
    });

    dropdownContent.addEventListener("click", function(event) {
        event.stopPropagation(); // Impede que o clique dentro do dropdown feche ele
    });
});