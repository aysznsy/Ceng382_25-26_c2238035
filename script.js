document.addEventListener("DOMContentLoaded", function() {
  document.getElementById("showLoginBtn").addEventListener("click", function() {
      document.getElementById("loginForm").style.display = "block";
      document.getElementById("showLoginBtn").classList.add("hidden");
  });

  document.getElementById("closeLoginBtn").addEventListener("click", function() {
      document.getElementById("loginForm").style.display = "none";
      document.getElementById("showLoginBtn").classList.remove("hidden");
  });

  function updateClock() {
      const now = new Date();
      const hours = now.getHours().toString().padStart(2, '0');
      const minutes = now.getMinutes().toString().padStart(2, '0');
      const seconds = now.getSeconds().toString().padStart(2, '0');
      document.getElementById("liveClock").textContent = `${hours}:${minutes}:${seconds}`;
  }
  setInterval(updateClock, 1000);
  updateClock();

  document.addEventListener("keydown", function(event) {
    if (event.key === "h" || event.key === "H") {
        
        
      const elementsToHide = document.querySelectorAll("form, #liveClock, img, #closeLoginBtn, #loginBackground");
        
        elementsToHide.forEach(element => {
            element.classList.toggle("hidden");
        });
    }
});
});
