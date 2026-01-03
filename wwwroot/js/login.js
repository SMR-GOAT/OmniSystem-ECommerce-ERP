document.addEventListener("DOMContentLoaded", function () {
  const userNameField = document.getElementById("userNameInput");
  const rememberMeCheck = document.getElementById("rememberMeCheck");
  const loginForm = document.getElementById("loginForm");

  // 1. عند تحميل الصفحة: تحقق لو فيه اسم محفوظ
  const savedName = localStorage.getItem("smr_saved_username");
  if (savedName) {
    if (userNameField) userNameField.value = savedName;
    if (rememberMeCheck) rememberMeCheck.checked = true;
  }

  // 2. عند الضغط على زر الدخول: احفظ أو امسح الاسم بناءً على الخيار
  if (loginForm) {
    loginForm.addEventListener("submit", function () {
      if (rememberMeCheck.checked) {
        localStorage.setItem("smr_saved_username", userNameField.value);
      } else {
        localStorage.removeItem("smr_saved_username");
      }
    });
  }
});
