var baseURL = "http://localhost:5005";

// function load() {
//     fetch(baseURL + '/my project')//לא בטוח ניתוב טוב 
//         .then((res) => res.json())
//         .then((data) => PizzaTbl(data))
//         .catch((error) => console.log(error))
// }

// function PizzaTbl(data) {
//     var table = document.getElementById('pizzalist');
//     data.forEach(function (pi) {
//         var tr = document.createElement('tr');
//         tr.innerHTML = '<td>' + pi.Name + '</td>' +
//             '<td>' + pi.IsGlutan + '</td>' +
//             '<td>' + pi.Id + '</td>'
//             ;
//         var tBody = table.getElementsByTagName('tbody')[0];
//         tBody.appendChild(tr);
//     });
// }

function addPizza() {
    var mypizza = {};
    mypizza.Name = document.getElementById('Name').value;
    mypizza.IsGlutan = document.getElementById('IsGlutan').value;
    mypizza.Id = document.getElementById('Id').value;


    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    

    var raw = JSON.stringify(mypizza);

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw
    };
    console.log("Sending data:", raw);
    fetch(baseURL + "/api/PizzaTata/PostPizza", requestOptions)
        // .then(response => afterPost())
        .then((result) => alert("good"))
        .catch(error => console.log('error', error));
}

// function afterPost(params) {
//     alert("good");
//     load();
// }