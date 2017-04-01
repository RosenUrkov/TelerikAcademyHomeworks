window.addEventListener('load', function() {
    const canvas = document.getElementsByTagName('canvas')[0],
        context = canvas.getContext('2d'),

        gameObjectWidth = 40,
        gameObjectHeight = 40,
        gameSpeed = 7,

        snakeInitialLength = 3,
        snake = new Snake(canvas, context, { width: gameObjectWidth, height: gameObjectHeight }, snakeInitialLength, gameSpeed),
        food = new Food(canvas, context, { width: gameObjectWidth / 2, height: gameObjectHeight / 2 }),

        DIRECTIONS = {
            ArrowUp: { x: 0, y: -1 },
            ArrowLeft: { x: -1, y: 0 },
            ArrowDown: { x: 0, y: 1 },
            ArrowRight: { x: 1, y: 0 }
        };

    let direction = { x: 1, y: 0 };
    document.addEventListener('keydown', function(event) {
        if (!DIRECTIONS.hasOwnProperty(event.key)) {
            return;
        }

        direction = DIRECTIONS[event.key];
    });

    context.font = "30px Arial";

    function renderScore(score) {
        context.clearRect(630, 25, 170, 30);
        context.fillStyle = 'gray';
        context.fillText(`Score ${score}`, 630, 50);
    }

    function gameOver() {
        context.font = "60px Arial";
        context.fillStyle = 'gray';
        context.fillText(`GAME OVER!`, canvas.width / 2 - 180, canvas.height / 2);
    }

    (function gameLoop() {
        renderScore(snake.score);

        food.render();

        snake
            .render()
            .update(direction)
            .tryEatFood(food);

        if (!snake.isAlive) {
            gameOver();
            return;
        }

        window.requestAnimationFrame(gameLoop);
    }());
});