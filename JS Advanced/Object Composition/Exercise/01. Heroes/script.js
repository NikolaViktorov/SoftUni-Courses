function solve() {
    function mage(name) {
        const inst = {
            name,
            health : 100,
            mana : 100,
            cast
        }
        
        function cast(spell) {
            inst.mana--;
            console.log(`${inst.name} cast ${spell}!`);
        }

        return  inst;
    }
    function fighter(name) {
        const inst = {
            name,
            health : 100,
            stamina : 100,
            fight
        }
        
        function fight() {
            inst.stamina--;
            console.log(`${inst.name} slashes at the foe!`);
        }

        return inst;
    }

    return {mage, fighter};
}


let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);