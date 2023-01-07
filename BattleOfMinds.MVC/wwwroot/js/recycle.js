
const noQuestion = () => {
        
        if(question_list.length == 0){setTimeout(function () {
                window.alert('The removed question could not be found.');
            }, 100000);
                
        }

}


const addCode = (question_list, id_list) => {
    for(let i = 0 ; i < question_list.length;i++){
    let html =
        '<div class="short-question" id = ' + id_list[i] +'>\
      '+question_list[i].substring(0,46)+'\
    </div>';
    
            document.getElementById("questions").innerHTML +=html;
}         


        }


/*
const onClick = (event) => {
        let vara = (event.srcElement.id);
        document.getElementById(vara).remove();
      }
      window.addEventListener('click', onClick);
      */
      
noQuestion();
addCode();
      
