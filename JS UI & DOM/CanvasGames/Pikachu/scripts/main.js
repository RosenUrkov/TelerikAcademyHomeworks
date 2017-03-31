window.addEventListener('load', function() {

    const canvas = document.getElementsByTagName('canvas')[0],
        pikachuContext = canvas.getContext('2d'),
        pikachuRunningImg = document.getElementById('pikachu-sprite'),
        pikachuJumpingImg = document.getElementById('pikachu-jumping'),

        pokeballContext = document.getElementsByTagName('canvas')[1].getContext('2d'),
        pokeballImg = document.getElementById('pokeball-sprite'),

        background = createBackground(),

        pikachuRunning = createSprite({
            spritesheet: pikachuRunningImg,
            context: pikachuContext,
            width: pikachuRunningImg.width / 4,
            height: pikachuRunningImg.height,
            numberOfFrames: 4,
            loopTicksPerFrame: 3,
        }),

        pikachuJumping = createSprite({
            spritesheet: pikachuJumpingImg,
            context: pikachuContext,
            width: pikachuJumpingImg.width / 2,
            height: pikachuJumpingImg.height,
            numberOfFrames: 2,
            loopTicksPerFrame: 35
        }),

        pikachuBody = createPhysicalBody({
            coordinates: { x: 0, y: canvas.height - pikachuRunning.height },
            width: pikachuRunningImg.width / 4,
            height: pikachuRunningImg.height,
            speed: { x: 0, y: 0 }
        }),

        pokeballs = [],
        PIKACHU_SPEED = 7,
        POKEBALL_SPEED = 5;

    function createPokeball(offsetX) {
        const pokeballSprite = createSprite({
                spritesheet: pokeballImg,
                context: pokeballContext,
                width: pokeballImg.width / 18,
                height: pokeballImg.height,
                numberOfFrames: 18,
                loopTicksPerFrame: 3
            }),

            pokeballBody = createPhysicalBody({
                coordinates: { x: offsetX, y: canvas.height - pokeballSprite.height },
                width: pokeballImg.width / 18,
                height: pokeballImg.height,
                speed: { x: -5, y: 0 }
            });

        return {
            sprite: pokeballSprite,
            body: pokeballBody
        }
    }

    function spawnPokeball() {
        if (Math.random() < 0.02) {
            if (pokeballs.length) {
                const ball = pokeballs[pokeballs.length - 1],
                    starting = Math.max(ball.body.coordinates.x + ball.body.width + 10, canvas.width);
                pokeballs.push(createPokeball(starting));
            } else {
                pokeballs.push(createPokeball(canvas.width));
            }
        }
    }

    document.addEventListener('keydown', function(event) {
        switch (event.keyCode) {
            case 37:
                pikachuBody.speed.x = -PIKACHU_SPEED;
                break;
            case 38:
                if (pikachuBody.coordinates.y < (canvas.height - pikachuBody.height)) {
                    return;
                }
                pikachuBody.speed.y = -PIKACHU_SPEED;
                break;
            case 39:
                pikachuBody.speed.x = PIKACHU_SPEED;
                break;
            default:
                return;
        }
    });

    let currentPikachuSprite = pikachuRunning;

    function gameLoop() {
        applyGravity(pikachuBody, canvas.height);
        removeAcceleration(pikachuBody);

        let lastPikachuCordinates = pikachuBody.move();

        if ((pikachuBody.coordinates.y + pikachuBody.height) < canvas.height) {
            currentPikachuSprite = pikachuJumping;
        } else {
            currentPikachuSprite = pikachuRunning;
        }

        currentPikachuSprite
            .render(pikachuBody.coordinates, lastPikachuCordinates)
            .update();

        for (const pokeball of pokeballs) {
            let lastPokeballCoordinates = pokeball.body.move();
            pokeball.sprite
                .render(pokeball.body.coordinates, lastPokeballCoordinates)
                .update();

            if (pokeball.body.coordinates.x < -pokeball.body.width) {
                pokeballs.shift();
                continue;
            }

            if (pikachuBody.collidesWith(pokeball.body)) {
                const deadImage = document.getElementById('pikachu-dead');

                gameOverAudio = document.getElementById('game-over-song').play();
                pikachuContext.drawImage(
                    deadImage,
                    pikachuBody.coordinates.x - 100,
                    pikachuBody.coordinates.y - 130
                );

                return;
            }
        };

        spawnPokeball();

        background.render();
        background.update(canvas.width);

        window.requestAnimationFrame(gameLoop);
    }

    gameLoop();
});