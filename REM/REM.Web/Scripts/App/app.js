$(function () {

    $('table').on('click', 'tr[data-href]', function () {
        var href = $(this).data('href');
        if (href) {
            window.location = href;
        }
    });

});

function ClearAndSubmitForm(self) {
    var form = $(self).closest('form');

    form.find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'select-multiple':
            case 'select-one':
            case 'text':
            case 'textarea':
                $(this).val("");
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}