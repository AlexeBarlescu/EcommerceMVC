// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let minusButtons = document.querySelectorAll("[id^='minus_']");

minusButtons.forEach((button, index) => {
    let buttonId = button.attributes['id'].value;
    let inputId = buttonId.replace('minus','input');
    let input = document.getElementById(inputId);
    
    button.addEventListener('click', event => {
        event.preventDefault();
        let inputValue = parseInt(input.value.toString());
        if(isNaN(inputValue)) inputValue = 1;
        if(inputValue === 1) return;
        inputValue -= 1;
        input.value = inputValue;
    });
});

let plusButtons = document.querySelectorAll("[id^='plus_']");

plusButtons.forEach((button, index) => {
    let buttonId = button.attributes['id'].value;
    let inputId = buttonId.replace('plus','input');
    let input = document.getElementById(inputId);
    
    button.addEventListener('click', event => {
        event.preventDefault();
        let inputValue = parseInt(input.value.toString());
        if(isNaN(inputValue)) inputValue = 1;
        if(inputValue === 20) return;
        inputValue += 1;
        input.value = inputValue.toString();
    });
});

