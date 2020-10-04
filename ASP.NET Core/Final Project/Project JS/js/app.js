import { getChampionById, getUserBySummonerName, getMatchesByEncAccId, getMatchById } from './data.js';
import { createTable } from './controllers/match.js';


window.addEventListener('load', () => {
    const nameInputEl = document.getElementById('name');
    const containerEl = document.getElementById('container');
    const loadingEl = document.getElementById('loading');
    const numberGamesInputEl = document.getElementById('numberGames');
    
    const submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', renderData)
    
    async function renderData(e) {
        e.preventDefault();

        try {
            loadingEl.classList.remove('hidden');
            containerEl.innerHTML = '';
            submitBtn.disabled = true;
            const data = await getUserBySummonerName(nameInputEl.value);
            const matches = await getMatchesByEncAccId(data.accountId);

            const lastMatches = [];
            for (let i = 0; i < +numberGamesInputEl.value; i++) {
                lastMatches[i] = matches.matches[i];
            }

            for (let i = 0; i < +numberGamesInputEl.value; i++) {
                const data = await getMatchData(lastMatches[i].gameId);
                
                const table = createTable(data.names, data.champNames,
                     data.profileIconIds, data.firstTeamState,
                      data.secondTeamState);
                containerEl.appendChild(table);
            }     
        } catch (error) {
            console.error(error);
        } finally {
            loadingEl.classList.add('hidden');
            submitBtn.disabled = false;
        }
    }
});

async function getMatchData(gameId) {
        const match = await getMatchById(gameId);

        const firstTeamState = match.teams[0].win;
        const secondTeamState = match.teams[1].win;

        const participants = match.participants;
        participants.sort(p => p.participantId);

        const participantIdentities = match.participantIdentities;
        participantIdentities.sort(p => p.participantId);

        const profileIconIds = [];
        const names = [];
        participantIdentities.forEach(p => {
            profileIconIds.push(p.player.profileIcon);
            const id = p.participantId;

            // get largest multi kill name per person
            let largestMultiKill = getMultikillName(participants[id - 1].stats.largestMultiKill);
            
            names.push(p.player.summonerName + ` ${participants[id - 1].stats.kills}`
            + `/${participants[id - 1].stats.deaths}` + `/${participants[id - 1].stats.assists}` +
            `${largestMultiKill !== '' ? ` ${largestMultiKill}` : ''}`);
        });

        const champNames = await getChampNames(participants);

        return {
            names,
            champNames,
            profileIconIds,
            firstTeamState,
            secondTeamState
        }
}

function getMultikillName(largestMultiKillId) {
    switch(largestMultiKillId) {
        case 2: return 'Double Kill';
        case 3: return 'Triple Kill';
        case 4: return 'Quadra Kill';
        case 5: return 'Penta Kill';
        case 6: return 'Hexa Kill';
        default: return '';
    }
}

async function getChampNames(participants) {
    const champIds = [];
    participants.forEach(p => {
        champIds.push(p.championId);
    })

    const champions = await getChampions(champIds);
    const champNames = [];
    champions.forEach(c => {
        champNames.push(c.name);
    });

    return champNames;
}

async function getChampions(ids) {
    const champs = [];

    let f = 0;
    for (let id of ids) {
        const list = await getChampionById(id);
        const champList = list.data;
    
        for (let i in champList) {
            if (champList[i].key == id) {
               champs[f] = champList[i]; 
               f++;
               break;
            }
            if (champList[i].key === '143') {
                champs[f] = { name: 'Not Found yet!' };
                f++;
            }
        }
    }
    return champs;
}