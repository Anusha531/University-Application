
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