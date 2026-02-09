
document.addEventListener('DOMContentLoaded', function () {

    const selectAll = document.querySelector('.sl-all');
    const mailChecks = document.querySelectorAll('.mail-check');

    // Üst checkbox'a basılınca
    selectAll.addEventListener('change', function () {
        mailChecks.forEach(cb => {
            cb.checked = selectAll.checked;
        });
    });

    // Tek tek mail checkbox'ları değişirse
    mailChecks.forEach(cb => {
        cb.addEventListener('change', function () {
            const allChecked = [...mailChecks].every(c => c.checked);
            const anyChecked = [...mailChecks].some(c => c.checked);

            selectAll.checked = allChecked;
            selectAll.indeterminate = !allChecked && anyChecked;
        });
    });


    document.addEventListener('click', function (e) {

        const starBtn = e.target.closest('.star-toggle');
        if (!starBtn) return;

        const icon = starBtn.querySelector('i');
        const row = starBtn.closest('tr');

        const inboxBody = document.getElementById('inboxMails');
        const starredBody = document.getElementById('starredMails');

        const isStarred = icon.classList.contains('fas');

        if (isStarred) {
            // ⭐ KALDIR → inbox'a geri taşı
            icon.classList.remove('fas');
            icon.classList.add('far');

            inboxBody.prepend(row); // üste geri at

        } else {
            // ⭐ EKLE → yıldızlılara taşı
            icon.classList.remove('far');
            icon.classList.add('fas');

            starredBody.prepend(row); // yıldızlılar en üstte
        }
    });

});