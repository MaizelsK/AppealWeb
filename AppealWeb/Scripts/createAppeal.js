ko.validation.locale('ru-RU');
ko.validation.init({

    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    errorClass: 'text-danger',
    messageTemplate: null

}, true);

var appealModel = {
    Theme: ko.observable().extend({
        required: true,
        minLength: 5,
        maxLength: 50
    }),
    Text: ko.observable().extend({
        required: true,
        minLength: 10,
        maxLength: 500
    }),
    
    postBtn: function () {
        var data = {
            Theme: this.Theme(),
            Text: this.Text(),
        };

        postData(data);
    }
}
ko.applyBindings(appealModel);

var postData = function (data) {
    $.post("/Appeals/Create", data, function (result) {
        if (result.IsSuccess) {
            alert("Вашe обращение успешно создано!");
            location.pathname = "/Appeals/Index/";
        }
        else {
            $('#Text').before("<div class=\"alert alert-danger alert-dismissible\">" +
                "<a class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>" +
                result.ErrorMsg
                + "</div>")
        }
    })
}