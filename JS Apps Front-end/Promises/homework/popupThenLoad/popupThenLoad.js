window.addEventListener('load', function() {
    const div = document.createElement('div');
    div.className = 'popup';
    document.body.appendChild(div);

    let currentFrame = 0,
        animationFrames = 5;

    (function switchColor() {
        if (currentFrame > animationFrames) {
            currentFrame = 0;

            if (div.style.backgroundColor === 'red') {
                div.style.backgroundColor = 'white';
            } else {
                div.style.backgroundColor = 'red';
            }
        }
        currentFrame += 1;

        window.requestAnimationFrame(switchColor);
    }());

    let isPopped = false;
    document.addEventListener('click', function() {
        if (isPopped) {
            return;
        }

        isPopped = true;

        document.getElementById('message').style.display = 'none';
        div.innerHTML = 'Redirecting to Google...';

        new Promise((resolve, reject) => setTimeout(resolve, 500))
            .then(() => div.style.display = 'block')
            .then(() => {
                return new Promise(function(resolve, reject) {
                    const outcome = (Math.random() * 2) | 0;
                    setTimeout(arguments[outcome], 2000);
                })
            })
            .then(() => window.location.href = 'https://www.google.bg/')
            .catch(() => {
                div.innerHTML = 'Failed to redirect!';
                isPopped = false;
            });
    });
});