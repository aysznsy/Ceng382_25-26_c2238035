document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("showLoginBtn").addEventListener("click", function() {
        document.getElementById("loginForm").style.display = "block"; 
        document.getElementById("showLoginBtn").classList.add("hidden");
    });

    document.getElementById("closeLoginBtn").addEventListener("click", function() {
        document.getElementById("loginForm").style.display = "none"; 
        document.getElementById("showLoginBtn").classList.remove("hidden");
    });

    document.addEventListener("keydown", function(event) {
        if (event.key === "h" || event.key === "H") {
            const loginForm = document.getElementById("loginForm");
            if (loginForm.style.display === "none" || loginForm.style.display === "") {
                loginForm.style.display = "block";
            } else {
                loginForm.style.display = "none";
            }
        }
    });

    const loginFormElement = document.getElementById('loginForm');
    
    loginFormElement.addEventListener('submit', (event) => {
        event.preventDefault();

        const username = document.querySelector('input[placeholder="Username"]').value; 
        const password = document.querySelector('input[placeholder="Password"]').value; 

        if (username === 'admin' && password === 'admin') {
            window.location.href = 'table.html'; 
        } else {
            alert('Incorrect username or password.');
        }
    });

    function updateClock() {
        const clockElement = document.getElementById("liveClock");
        if (!clockElement) {
            console.error("I put this to understand the display issue of liveclock");
            return;
        }

        const now = new Date();
        const hours = now.getHours().toString().padStart(2, "0");
        const minutes = now.getMinutes().toString().padStart(2, "0");
        const seconds = now.getSeconds().toString().padStart(2, "0");
        clockElement.textContent = `${hours}:${minutes}:${seconds}`;
    }

    updateClock();
    setInterval(updateClock, 1000);
});