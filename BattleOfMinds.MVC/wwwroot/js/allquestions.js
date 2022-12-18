
let question_list = ["Hollanda'nın başkenti neresidir?","2.Dünya savaşı hangisinin üzerine başlamıştır?","Hangi şair İkinci Yeni akımına dahildir?"," İstiklal Marşı hangi yıl yazılmıştır?","Bu bayrak hangi ülkeye aittir?","as'ın başkenti hangi şehirdir?","1’in türevi kaçtır?","Bir elektrik devresinde direnç hangi harfle gösterilir?","Kuyucaklı Yusuf adlı eser kime aittir?"];



function addCode() {
    for(let i = 0 ; i < question_list.length;i++){
    let html =
    '<div class="short-question" id = "q'+i+'">\
      '+question_list[i].substring(0,46)+'  \
      <i class="fa-solid fa-trash" onclick ="onClick()"></i>\
      <a href = "/Questions/Edit"><i class="fa-sharp fa-solid fa-pen"></i></a>\
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

