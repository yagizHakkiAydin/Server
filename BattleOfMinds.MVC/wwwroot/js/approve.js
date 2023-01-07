
/*let question_list = ["Hollanda'nýn baþkenti neresidir?", "2.Dünya savaþý hangisinin üzerine baþlamýþtýr?", "Hangi þair Ýkinci Yeni akýmýna dahildir?", " Ýstiklal Marþý hangi yýl yazýlmýþtýr?", "Bu bayrak hangi ülkeye aittir?", "as'ýn baþkenti hangi þehirdir?", "1’in türevi kaçtýr?", "Bir elektrik devresinde direnç hangi harfle gösterilir?", "Kuyucaklý Yusuf adlý eser kime aittir?"];



function addCode() {
    for (let i = 0; i < question_list.length; i++) {
        let html =
            '<div class="short-question" id = "q' + i + '">\
      '+ question_list[i].substring(0, 46) + '  \
      <i class="fa-solid fa-regular fa-x" ></i>\
      <i class="fa-solid fa-check fa-lg"></i>\
    </div>';

        document.getElementById("questions").innerHTML += html;
    }


}


addCode();

*/


function addCode(question_list, id_list) {
    for (let i = 0; i < question_list.length; i++) {
        let html =
            '<div class="short-question" id = ' + id_list[i] + '>\
      '+ question_list[i].substring(0, 46) + '  \
      <a href = "/Questions/Reject?id='+ id_list[i] +'"> <i class="fa-solid fa-regular fa-x"></i></a>\
      <a href = "/Questions/Approve?id='+ id_list[i] +'"><i class="fa-solid fa-check"></i></a>\
    </div>';

        document.getElementById("questions").innerHTML += html;
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
