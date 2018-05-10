(function() {
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
        FileInput: ko.observable(),

        error: ko.observable(),

        postBtn: function () {

            var data = {
                Theme: this.Theme(),
                Text: this.Text(),
                FileData: this.FileInput()
            };

            postData(data);
        }
    }
    ko.applyBindings(appealModel);

    var postData = function (data) {
        appealModel.error('');

        var form = new FormData();
        form.append("Theme", data.Theme);
        form.append("Text", data.Text);
        form.append("FileData", data.FileData);

        $.ajax({
            url: '/Appeals/Create',
            type: 'POST',
            contentType: false,
            processData: false,
            data: form,
            success: function (result) {
                if (result.IsSuccess) {
                    alert("Вашe обращение успешно создано!");
                    location.pathname = "/Appeals/Index/";
                }
                else {
                    appealModel.error("<div class=\"alert alert-danger alert-dismissible\">" +
                        "<a class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>" +
                        result.ErrorMsg
                        + "</div>");
                }
            }
        });
    }
})();