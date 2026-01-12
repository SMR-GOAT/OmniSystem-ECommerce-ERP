$(document).ready(function () {
    var alertElement = $("#success-alert");
    
    if (alertElement.length > 0) {
        // 1. إظهار الرسالة (تنزل من فوق)
        setTimeout(function () {
            alertElement.addClass("show-now");
        }, 100);

        // 2. البدء في الإخفاء التدريجي بعد 3 ثوانٍ
        setTimeout(function () {
            alertElement.addClass("fade-out");
        }, 3000);

        // 3. حذف العنصر نهائياً من الـ DOM بعد انتهاء حركة الإخفاء
        setTimeout(function () {
            alertElement.remove();
        }, 3800);
    }
});
 