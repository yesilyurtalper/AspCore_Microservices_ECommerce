
function LoadDDItemsAndSelectOne(apiurl, dropDownId, value, check) {
    $.ajax(
        {
            type: "GET",
            url: apiurl,
            success:
                function (response) {
                    console.log(response);
                    $(dropDownId).html('');
                    var options = '';
                    for (var i = 0; i < response.length; i++)
                        options += '<option value="' + response[i].id + '">' + response[i].name + '</option>';
                    $(dropDownId).append(options);
                    console.log(options);
                    if (check != "")
                        $(dropDownId).val(value);
                    else
                        $(dropDownId).val($(dropDownId).options[0].val());
                },
            error: function (response) { alert("Error loading entities async: " + response); }
        }
    );  
}