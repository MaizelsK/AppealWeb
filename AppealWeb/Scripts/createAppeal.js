(function () {
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

        isVisible: ko.observable(false),
        error: ko.observable(),

        postBtn: function () {

            var data = {
                Theme: this.Theme(),
                Text: this.Text(),
                FileData: this.FileInput(),
                okClick: function () { },
                child:
                {
                    id: 1,
                    name: 'qwdqw',
                    child:
                    {
                        id: 1,
                        name: 'qwdqw'
                    }
                }
            };

            postData(data);
        }
    }
    ko.applyBindings(appealModel);

    var postData = function (data) {
        appealModel.isVisible(false);
        appealModel.error('');

        var form = convert(data);

        console.log(form.get('child.child.id'));
        console.log(form.get('child.child.name'));

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
                    appealModel.isVisible(true);
                    appealModel.error(result.ErrorMsg);
                }
            }
        });
    }
})();