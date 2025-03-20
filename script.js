document.addEventListener("DOMContentLoaded", function() {
  document.getElementById("showLoginBtn").addEventListener("click", function() {
      document.getElementById("loginForm").style.display = "block";
      document.getElementById("showLoginBtn").classList.add("hidden");
  });

  document.getElementById("closeLoginBtn").addEventListener("click", function() {
      document.getElementById("loginForm").style.display = "none";
      document.getElementById("showLoginBtn").classList.remove("hidden");
  });

});
