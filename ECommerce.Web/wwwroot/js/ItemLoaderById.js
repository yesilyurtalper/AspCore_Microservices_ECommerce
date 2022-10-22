
function LoadItemsById(apiurl, itemType, spanId) {
    $.ajax(
        {
            type: "GET",
            url: apiurl,
            success:
                function (response) {
                    console.log(response);
                    $(spanId).text('');
                    var innerText = '';
                    for (var i = 0; i < response.length; i++)
                        innerText += '<a href="../../' + itemType + '/Details/' + response[i].id + '">' + response[i].name + '</a> , ';
  
                    $(spanId).html(innerText.substring(0, innerText.length - 3));                 
                },
            error: function (response) { alert("Error loading entities async: " + response); }
        }
    );  
}