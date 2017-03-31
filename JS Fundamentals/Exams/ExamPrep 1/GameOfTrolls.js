function solve(args) {
    var rowsAndCols = args[0].split(' ').map(Number),
        rows = rowsAndCols[0],
        cols = rowsAndCols[1],
        matrix = new Array(rows),
        coordinates = args[1].split(/[ ;]/g).map(Number),
        wTroll = MakeCreature(coordinates[0], coordinates[1]),
        nTroll = MakeCreature(coordinates[2], coordinates[3]),
        princess = MakeCreature(coordinates[4], coordinates[5]),
        commands = args.slice(2);

    for (let i = 0, length = rows; i < length; i += 1) {
        matrix[i] = new Array(cols);
    }

    function MakeCreature(row, col) {
        return {
            Row: row,
            Col: col,
            inTrap: false
        };
    }

    for (var command of commands) {
        var piecedCommands = command.split(' '),
            output;
        if (piecedCommands[0] == 'mv') {
            output = Move(piecedCommands[1], piecedCommands[2]);
            if (output !== undefined) {
                console.log(output);
                return;
            }
        } else {
            matrix[princess.Row][princess.Col] = true;
        }
    }


    function Move(creature, direction) {
        if (creature === 'Lsjtujzbo') {
            var out;
            Position(princess, direction);

            //check here if fails
            out = CheckPrincess(wTroll);
            if (out !== undefined) {
                return out;
            }
            out = CheckPrincess(nTroll);
            if (out !== undefined) {
                return out;
            }

            if ((princess.Row === rows - 1) && (princess.Col === cols - 1)) {
                return `Lsjtujzbo is saved! ${wTroll.Row} ${wTroll.Col} ${nTroll.Row} ${nTroll.Col}`;
            }
            return;
        }
        if (creature === 'Wboup') {
            if (wTroll.inTrap === true) {
                return;
            }

            Position(wTroll, direction);

            if (matrix[wTroll.Row][wTroll.Col] === true && (wTroll.Row === nTroll.Row && wTroll.Col === nTroll.Col)) {
                matrix[wTroll.Row][wTroll.Col] = undefined;
                nTroll.inTrap = false;
            } else if (matrix[wTroll.Row][wTroll.Col] === true) {
                wTroll.inTrap = true;
                if (nTroll.inTrap === true) {
                    return `Lsjtujzbo is saved! ${wTroll.Row} ${wTroll.Col} ${nTroll.Row} ${nTroll.Col}`;
                }
            }

            return CheckPrincess(wTroll);
        }
        if (creature === 'Nbslbub') {
            if (nTroll.inTrap === true) {
                return;
            }

            Position(nTroll, direction);

            if (matrix[nTroll.Row][nTroll.Col] === true && (nTroll.Row === wTroll.Row && nTroll.Col === wTroll.Col)) {
                matrix[nTroll.Row][nTroll.Col] = undefined;
                wTroll.inTrap = false;
            } else if (matrix[nTroll.Row][nTroll.Col] === true) {
                nTroll.inTrap = true;
                if (wTroll.inTrap === true) {
                    return `Lsjtujzbo is saved! ${wTroll.Row} ${wTroll.Col} ${nTroll.Row} ${nTroll.Col}`;
                }
            }

            return CheckPrincess(nTroll);
        }
    }

    function Position(char, dir) {
        if (dir === 'u') {
            if (char.Row === 0) {
                return;
            }
            char.Row -= 1;
            return;
        }
        if (dir === 'd') {
            if (char.Row + 1 === rows) {
                return;
            }
            char.Row += 1;
            return;
        }
        if (dir === 'l') {
            if (char.Col === 0) {
                return;
            }
            char.Col -= 1;
            return;
        }
        if (dir === 'r') {
            if (char.Col + 1 === cols) {
                return;
            }
            char.Col += 1;
            return;
        }
    }

    function CheckPrincess(troll) {
        if ((troll.Row + 1 === princess.Row || troll.Row - 1 === princess.Row || troll.Row === princess.Row) &&
            (troll.Col + 1 === princess.Col || troll.Col - 1 === princess.Col || troll.Col === princess.Col)) {
            return `The trolls caught Lsjtujzbo at ${princess.Row} ${princess.Col}`;
        }
    }

}

solve([
    '5 5',
    '1 1;0 1;2 3',
    'mv Lsjtujzbo d',
    'lay trap',
    'mv Lsjtujzbo d',
    'mv Wboup r',
    'mv Wboup r',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Wboup d',
    'mv Wboup d'
]);

solve([
    '7 7',
    '0 1;0 2;3 3',
    'mv Lsjtujzbo l',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo d',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup l',
    'mv Wboup l',
    'mv Nbslbub r',
    'mv Nbslbub r',
    'mv Nbslbub r',
    'mv Nbslbub d',
    'mv Lsjtujzbo d',
    'mv Lsjtujzbo l',
    'mv Lsjtujzbo l',
    'mv Nbslbub l',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup r',
    'mv Lsjtujzbo d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r'
]);