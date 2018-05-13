var convert = function (data) {
    var formData = new FormData();

    var loop = function (data, formData, keyName) {
        for (var key in data) {
            if (data[key] instanceof Function) {
                continue;
            }

            if (typeof (data[key]) === 'object'
                && !(data[key] instanceof File)) {
                loop(data[key], formData, keyName == null ? key : keyName + '.' + key);
            }
            else {
                formData.append(keyName == null ? key : keyName + '.' + key, data[key]);
            }
        }
    }

    loop(data, formData, undefined);

    return formData;
}

//requireJS


//(function() {
//        function convert() { };
//        function loop() { };
//        window["ConvertFromJsonToFormData"] = convert;
//})()