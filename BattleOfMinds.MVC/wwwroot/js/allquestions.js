
function addCode(question_list,id_list) {
    for(let i = 0 ; i < question_list.length;i++){
        let html =
            '<div class="short-question" id = '+ id_list[i] +'>\
      '+question_list[i].substring(0,46)+'...  \
      <i class="fa-solid fa-trash" onclick="DeleteOnclick('+ id_list[i] + ')"></i>\
      <a href = "/Questions/Edit?id='+ id_list[i] +'" ><i class="fa-sharp fa-solid fa-pen"></i></a>\
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
      
addCode();

