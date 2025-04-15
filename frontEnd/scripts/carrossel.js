/*Seleciona a primeira imagem por padrão*/
let i = 1;
document.getElementById("radio1").checked = true;

/*Roda a função nextImage a cada 3 segundos*/
setInterval( function(){
    nextImage();
}, 3000)
/*Função que diz qual imagem deve ser selecionada*/
function nextImage(){
    i++;
    if(i > 4){
        i = 1;
    }
    document.getElementById("radio"+i).checked = true;
}