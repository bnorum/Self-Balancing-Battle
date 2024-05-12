let player = {
    health: 100,
    maxhp: 100,
    mana: 20,
    maxmana: 20,
    attackPower: 10,
    magicPower: 20,
    totalMagicAttacks: 0,
    totalAttacks: 0,
};
let enemy = {
    health: 100,
    maxhp: 100,
    attackPower: 10,
};

var totalTurns = 0;
var damageTaken = 0;


window.onload = function () {
    updateStats();
};

    // outline:
    // we want the battle to last ~10 turns
    // magic attacks are strongest, but we want to encourage both. We add risk to these, but adjust their power dynamically. Players should prioritize magic attacks.
    // we want the player to have to use both attacks to win. To do this, we make magic unspammable, regen 3 mana per turn, and start with 20 mana.

    // we want the enemy to be a challenge, but not impossible. We adjust their health and attack power dynamically.

    // ultimately, we do the following:
    // when a player stomps the enemy (check hp and turns for this) we buff the enemy HP or attack.
    // an over-reliance on either attack will nerf that attack and buff the other. But magic will always be stronger.
    // if enemy becomes too strong, we nerf them. This is a random choice between player HP buff or enemy Attack nerf.

    // How do we make these calculations?
    // We take the average of each stat, and then the standard deviation
    // If the standard deviation + average goes against the recommended value, we adjust the stats accordingly.

    //RECOMMENDED VALUES
    //PHP: 100
    //PMP: 20
    //PATK: 10
    //PMAG: 4 //this is total num of m attacks
    //PATKS: 6 //total num of attacks

    //EHP: 100
    //EATK: 10

    //TURNS: 10

    

function attack() {
    let damage = Math.floor(Math.random() * player.attackPower) + 2;
    let enemyDamage = Math.floor(Math.random() * enemy.attackPower) + 5;
    
    enemy.health -= damage;
    addToBattleLog(`You dealt ${damage} damage to the enemy.`);
    if (enemy.health > 0) {
        player.health -= enemyDamage;
        addToBattleLog(`The enemy dealt ${enemyDamage} damage to you.`);
        damageTaken += enemyDamage;
    } 

    totalTurns += 1;
    updateStats();

    var battlelog = document.getElementById("battle-log");
    battlelog.scrollTop = battlelog.scrollHeight;
    checkEndGame();
    
}

function magicAttack() {
    if (player.mana >= 10) {
        let damage = Math.floor(Math.random() * player.magicPower) + 7; 
        let enemyDamage = Math.floor(Math.random() * enemy.attackPower) + 5;
        
        player.mana -= 10;
        enemy.health -= damage;

        if (enemy.health > 0) {
            player.health -= enemyDamage;
            addToBattleLog(`The enemy dealt ${enemyDamage} damage to you.`);
            damageTaken += enemyDamage;
        } 
        addToBattleLog(`You used magic for 10 MP and dealt ${damage} damage to the enemy.`);
        totalTurns += 1;
        updateStats();


        var battlelog = document.getElementById("battle-log");
        battlelog.scrollTop = battlelog.scrollHeight;
        checkEndGame();
        

    } else {
         addToBattleLog(`<p>Not enough mana to use magic attack!</p>`);
    }
}

function updateStats() {

    player.mana += 3;
    addToBattleLog(`Restored 3 MP!`);
    if (player.mana > 20) {
        player.mana = 20;
    }
    document.getElementById("currstats").innerHTML = `<p>HP: ${player.health} MP: ${player.mana}</p>`;
    document.getElementById("enemystats").innerText = `HP: ${enemy.health}`;
    
    document.getElementById("battle-log").scrollTop = document.getElementById("battle-log").scrollHeight;
}

function checkEndGame() {
    if (player.health <= 0) {
        document.getElementById("battle-log").innerHTML += `<p>You were defeated!</p>`;
        disableButtons();
    }
    if (enemy.health <= 0) {
        document.getElementById("battle-log").innerHTML += `<p>You Won!</p>`;
        disableButtons();
    }
    statsToDatabase();
}

function disableButtons() {
    document.getElementById("attackbutton").disabled = true;
    document.getElementById("magicbutton").disabled = true;
}

function addToBattleLog(string) {
    document.getElementById("battle-log").innerHTML += `<p>${string}</p>`;

}

