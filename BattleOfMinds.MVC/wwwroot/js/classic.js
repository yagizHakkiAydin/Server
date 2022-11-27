function alertFunction() {
    if(document.getElementById("qarea").value == '')
    {
    alert("You cannot perform this action without writing a question.");
    
    }
    else if(document.getElementById("answer-inp").value == ''){
    alert("You cannot perform this action without writing an answer.");
      
    }
    else{
        alert("Your question has been saved.");
    }
    
}


function deleteFunction(){
    if((document.getElementById("qarea").value != "") || (document.getElementById("answer-inp").value = "")){
    document.getElementById("qarea").value = "";
    document.getElementById("answer-inp").value = "";
    alert("Question and answer boxes cleared");
    }
    else{
        alert("Question and answer boxes are already empty");
    }
}

