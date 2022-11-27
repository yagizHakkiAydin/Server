var counter = 2;


function add_more_field() {
    if(counter < 6){
        let html =
'<div class="answer">\
 <label class="answer-label" id="alabel'+counter+'" for="answer">Choice-1</label>\
 <input class="answer-inp" id="ainp'+counter+'" type="text">\
 <i class="fa-solid fa-circle-plus fa-xl" id="icon-add" onclick="add_more_field()"></i>\
</div>';
var add = document.querySelector(".allanswer");
add.insertAdjacentHTML('beforeend',html);

        counter += 1;
    }
    else{
        alert("A question can consist of a maximum of 5 options.");
    }
   document.getElementById("alabel2").innerHTML = "Choice-2";
   document.getElementById("alabel3").innerHTML = "Choice-3";
   document.getElementById("alabel4").innerHTML = "Choice-4";
   document.getElementById("alabel5").innerHTML = "Choice-5"; 
}

function alertFunction() {
    
    if(document.getElementById("qarea").value == '')
    {
    alert("You cannot perform this action without writing a question.");
    
    }
    else if(document.querySelector(".answer-inp").value == ''){
        alert("You cannot perform this action without writing an answer.");
          
    }
    
    else if(document.querySelector(".true-answer-inp").value == ''){
    alert("You cannot perform this action without writing a correct answer.");
      
    }
    else{
        alert("Your question has been saved.");
    }
    
}

function deleteFunction(){
    if((document.getElementById("qarea").value != "") || (document.getElementById("answer-inp").value = "")){
    document.getElementById("myform").reset();
    alert("Question and answer boxes cleared");
    }
    else{
        alert("Question and answer boxes are already empty");
    }
}

