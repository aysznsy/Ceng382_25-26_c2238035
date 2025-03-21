document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('classForm');
    const tableBody = document.querySelector('#classTable tbody');
    const classTable = document.getElementById('classTable');

    form.addEventListener('submit', function(event) {
        event.preventDefault();

        const className = document.getElementById('className').value;
        const numberOfPeople = document.getElementById('numberOfPeople').value;
        const description = document.getElementById('description').value;

        const newRow = tableBody.insertRow();
        const cell1 = newRow.insertCell(0);
        const cell2 = newRow.insertCell(1);
        const cell3 = newRow.insertCell(2);

        cell1.textContent = className;
        cell2.textContent = numberOfPeople;
        cell3.textContent = description;

        document.getElementById('className').value = '';
        document.getElementById('numberOfPeople').value = '';
        document.getElementById('description').value = '';
    });

    const inputs = document.querySelectorAll('input, textarea');
    inputs.forEach(input => {
        input.addEventListener('focus', function() {
            this.style.borderColor = '#007bff';
        });
        input.addEventListener('blur', function() {
            this.style.borderColor = '#ddd';
        });
    });

    tableBody.addEventListener('click', function(event) {
        const target = event.target;
        if (target.tagName === 'TD') {
            const row = target.parentElement;
            console.log('Row clicked:', row.cells[0].textContent, row.cells[1].textContent, row.cells[2].textContent);
            row.classList.toggle('highlighted');
        }
    });

    classTable.addEventListener('click', function(event) {
        if (event.target.tagName === 'TABLE') {
            const rows = tableBody.querySelectorAll('tr');
            const data = Array.from(rows).map(row => {
                return {
                    className: row.cells[0].textContent,
                    numberOfPeople: row.cells[1].textContent,
                    description: row.cells[2].textContent
                };
            });
            console.log('All class entries:', data);
        }
    });
    
    tableBody.addEventListener('mouseover', function(event) {
        const target = event.target;
        if (target.tagName === 'TD') {
            target.parentElement.style.backgroundColor = '#8E004A';
        }
    });

    tableBody.addEventListener('mouseout', function(event) {
        const target = event.target;
        if (target.tagName === 'TD') {
            target.parentElement.style.backgroundColor = '';
        }
    });

    tableBody.addEventListener('dblclick', function(event) {
        const target = event.target;
        if (target.tagName === 'TD') {
            const row = target.parentElement;
            row.remove();
        }
    });
});