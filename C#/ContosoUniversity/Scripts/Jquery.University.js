
function fnReset(formID) {
    $(formID).find("input[type=text]").val("");
    $(formID).find("select").val("");
    $(formID).find("textarea").val("");
}

function fnTypeAhead(className, dataSource) {

    // constructs the suggestion engine
    var results = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.whitespace,
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        local: dataSource
    });


    $(className).typeahead({       
        hint: true,
        highlight: true,
        minLength: 1
    },
        {
            name: 'results',
            limit: 10,
            source: results
        });

}

function areYouSureState(buttonId) {
    $('form').areYouSure({ 'silent': true });

    $('form').on('dirty.areYouSure', function () {
        // Enable save button only as the form is dirty.
        $(buttonId).removeAttr('disabled');
        console.log("dirty!");
    });
    $('form').on('clean.areYouSure', function () {
        // Form is clean so nothing to save - disable the save button.
        $(buttonId).attr('disabled', 'disabled');
        console.log("clean");
    });
}

function formSubmitEdit(btnID, formID, rowID) {

    $(btnID).click(function (e) {
        e.preventDefault();
        var form = $(formID);
        tableID = form.data('table');

        $.ajax({
            url: form.attr("action"),
            method: form.attr("method"),// post
            data: form.serialize(),
            success: function (result) {
                $(tableID).find(rowID).replaceWith(result);
                fnReset(formID);
            }
        });

    });
}


function formSubmit(btnID, formID) {

    $(btnID).click(function (e) {
        e.preventDefault();
        var form = $(formID);
        tableID = form.data('table');

        $.ajax({
            url: form.attr("action"),
            method: form.attr("method"),// post
            data: form.serialize(),
            success: function (result) {
                $(tableID).find('tbody:first').prepend(result);
                fnReset(formID);
            }
        });

    });
}

function fnDropZone(divID, tableID) {

    var myurl = $(divID).attr('data-url');
    uploader = new Dropzone(divID, {
        url: myurl
    });//end drop zone

    uploader.on("success", function (file, response) {
        $(tableID).find('tbody:first').prepend(response).find('.datepicker').datepicker();

        if (!$('form').hasClass('dirty')) {
            $('form').trigger('rescan.areYouSure');
        }

        $("#dz-error-message span").text("");
    });

    uploader.on('error', function (file, response) {
        $("#dz-error-message span").text(response.Message);
        this.removeFile(file);
    });


}

function showModel(btnID, modelID, frmID, submitBtnID, rowID) {

    var myurl = $(btnID).data('url');

    $.ajax({
        url: myurl,
        type: "post",
        cache: false,
        success: function (result) {

            $(modelID).replaceWith(result);

            formSubmitEdit(submitBtnID, frmID, rowID);

            // show Modal
            $(modelID).modal('show');

        }
    });

}

function deleteRow(btnID, tableID, rowID) {

    if (confirm("Are you sure you want to delete this item?")) {
        var myurl = $(btnID).attr('data-url');
        $.ajax({
            type: "POST",
            url: myurl,
            cache: false,
            success: function (success) {
                $(tableID).find(rowID).remove();
            }
        });
    }
    return false;
}