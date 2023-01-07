
/*let question_list = ["Hollanda'n�n ba�kenti neresidir?", "2.D�nya sava�� hangisinin �zerine ba�lam��t�r?", "Hangi �air �kinci Yeni ak�m�na dahildir?", " �stiklal Mar�� hangi y�l yaz�lm��t�r?", "Bu bayrak hangi �lkeye aittir?", "as'�n ba�kenti hangi �ehirdir?", "1�in t�revi ka�t�r?", "Bir elektrik devresinde diren� hangi harfle g�sterilir?", "Kuyucakl� Yusuf adl� eser kime aittir?"];



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
