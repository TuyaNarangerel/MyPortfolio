// När sidan laddas, hämta projekt från API
document.addEventListener('DOMContentLoaded', () => {
    fetchProject();

    // Hämta referenser för menyn och ikonen
    const menuIcon = document.getElementById("menu-icon");
    const navbar = document.querySelector(".navbar");

    // Hantera klick på menyikonen för att visa/gömma menyn
    menuIcon.onclick = () => {
        menuIcon.classList.toggle('bx-x'); // Lägg till/kolla på 'bx-x' för att ändra ikon
        navbar.classList.toggle('active'); // Lägg till/kolla på 'active' för att visa menyn
    };
});

// Funktion för att hämta projekt från API
async function fetchProject() {
    try {
        const response = await fetch('https://your-api-url/api/projects');
        const projects = await response.json();
        const projectList = document.getElementById('project-list');

        projects.forEach(project => {
            const projectItem = document.createElement('div');
            projectItem.classList.add('project-item');
            projectItem.innerHTML = `
                <h3>${project.name}</h3>
                <p>${project.description}</p>
                <p><strong>Tech Stack:</strong> ${project.techStack}</p>
                <p><a href="${project.otherInfo}" target="_blank">More Info</a></p>
            `;
            projectList.appendChild(projectItem);
        });
    } catch (error) {
        console.error('Error fetching projects:', error);
    }
}

// Hantering av kontaktformuläret
document.getElementById('contact-form').addEventListener('submit', async function (event) {
    event.preventDefault();

    const formData = new FormData(this);
    const contactMessage = {
        name: formData.get('name'),
        email: formData.get('email'),
        subject: formData.get('subject'),
        message: formData.get('message'),
    };

    try {
        const response = await fetch('https://your-api-url/api/contact', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(contactMessage),
        });

        if (response.ok) {
            alert('Message sent successfully!');
            this.reset();
        } else {
            alert('Failed to send message. Please try again later.');
        }
    } catch (error) {
        console.error('Error sending message:', error);
    }
});

// Scrolljustering för menylänkar
document.querySelectorAll('.navbar a').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();

        const targetSection = document.querySelector(this.getAttribute('href'));
        const headerOffset = 80; // Justera denna höjd för din header
        const elementPosition = targetSection.getBoundingClientRect().top;
        const offsetPosition = elementPosition + window.scrollY - headerOffset;

        window.scrollTo({
            top: offsetPosition,
            behavior: 'smooth'
        });

        // Stäng menyn på mobil efter klick
        const navbar = document.querySelector(".navbar");
        navbar.classList.remove("active");
        menuIcon.classList.remove('bx-x'); // Ändra ikon tillbaka till hamburgermenyn
    });
});

// CSS för att hantera scroll och layout
const style = document.createElement('style');
style.textContent = `
html {
    font-size: 60%;
    overflow-x: hidden;
    scroll-padding-top: 80px; /* Justera denna höjd beroende på headerns faktiska höjd */
    scroll-behavior: smooth;
}
`;
document.head.appendChild(style);
