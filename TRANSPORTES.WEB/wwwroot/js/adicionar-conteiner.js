$(document).ready(function () {
    $('input, select').on('change keyup', function () {
        var empty = false;
        $('input, select').each(function () {
            if ($(this).val() == '') {
                empty = true;
            }
        });

        if (empty) {
            $('#btn-add-container').prop('disabled', true);
        } else {
            $('#btn-add-container').prop('disabled', false);
        }
    });
});