    'use strict';

    function createGame(pacmanSelector, mazeSelector) {
        const canvas = document.querySelector(pacmanSelector),
            context = canvas.getContext('2d'),

            mazeCanvas = document.querySelector(mazeSelector),
            mazeContext = mazeCanvas.getContext('2d'),

            wallImg = document.getElementById('wall'),

            gameSize = 30,
            loopTicksPerFrame = 10,
            speed = 3,

            directionsCode = {
                '37': { mouth: 2, x: -1, y: 0 },
                '38': { mouth: 3, x: 0, y: -1 },
                '39': { mouth: 0, x: 1, y: 0 },
                '40': { mouth: 1, x: 0, y: 1 },
            },

            pacman = getPacman({
                canvas,
                context,
                coordinates: { x: 0, y: 90 },
                size: gameSize - 5,
                direction: { mouth: 0, x: 0, y: 0 },
                speed,
                loopTicksPerFrame
            }),

            maze = getMaze({
                context: mazeContext,
                size: gameSize,
                wall: wallImg
            });

        canvas.width = maze.cols * gameSize;
        canvas.height = maze.rows * gameSize;

        mazeCanvas.width = maze.cols * gameSize;
        mazeCanvas.height = maze.rows * gameSize;

        document.addEventListener('keydown', function(event) {
            event.preventDefault();
            if (!directionsCode.hasOwnProperty(event.keyCode)) {
                return;
            }

            pacman.direction = directionsCode[event.keyCode];
        });

        maze.render();

        function gameLoop() {
            pacman
                .render()
                .update();

            maze.foodArray.forEach((food, index) => {
                food.render(context);

                if (collided(pacman, food)) {
                    maze.foodArray.splice(index, 1);
                }
            });

            pacman.isCollided = false;
            for (const wall of maze.wallArray) {
                if (collided(pacman, wall, 1) || collided(wall, pacman, 2)) {

                    pacman.isCollided = true;
                    break;
                }
            }

            window.requestAnimationFrame(gameLoop);
        }

        return {
            start: gameLoop
        };
    }