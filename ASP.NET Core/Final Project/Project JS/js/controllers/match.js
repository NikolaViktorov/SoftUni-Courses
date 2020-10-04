import el from '../dom.js';
import { getIconUrl, getChampionIconUrl } from '../data.js';
import * as t from '../champsNames.js';

export function createTable(names, champNames, profileIconIds, stateFirstTeam, stateSecondTeam) {
    const urlNames = [];

    // Fuction to format champ name for url -> Kai'sa = Kaisa / Jarvan IV = JarvanIV / 
    for(let i = 0; i < champNames.length; i++) {
        urlNames[i] = getChampionUrlName(champNames[i]);
    }

    const inn = [
        el('tr', [
            el('th', `${stateFirstTeam === 'Fail' ? 'Defeat' : 'Victory'}`, { className: stateFirstTeam}),
            el('th', '', { className: stateFirstTeam}),
            el('th', ``),
            el('th', `${stateSecondTeam === 'Fail' ? 'Defeat' : 'Victory'}`, { className: stateSecondTeam}),
            el('th', ``, { className: stateSecondTeam}),
        ]),
        el('tr', [
            el('th', 'Player Names'),
            el('th', 'Champ Names'),
            el('th', ' '),
            el('th', 'Player Names'),
            el('th', 'Champ Names'),
        ]),
        createRow([names[0], names[5]], [profileIconIds[0], profileIconIds[5]], [champNames[0], champNames[5]], [urlNames[0], urlNames[5]]),
        createRow([names[1], names[6]], [profileIconIds[1], profileIconIds[6]], [champNames[1], champNames[6]], [urlNames[1], urlNames[6]]),
        createRow([names[2], names[7]], [profileIconIds[2], profileIconIds[7]], [champNames[2], champNames[7]], [urlNames[2], urlNames[7]]),
        createRow([names[3], names[8]], [profileIconIds[3], profileIconIds[8]], [champNames[3], champNames[8]], [urlNames[3], urlNames[8]]),
        createRow([names[4], names[9]], [profileIconIds[4], profileIconIds[9]], [champNames[4], champNames[9]], [urlNames[4], urlNames[9]])
    ];
    const table = el('table', inn);

    return table;
}

function getChampionUrlName(name) {
    let urlName = name;

    if (t.names.hasOwnProperty(name)) {
        urlName = t.names[name];
    }

    return urlName;
}

function createRow(names, iconIds, champNames, urlNames) {
    const row = el('tr', [
        el('td', [
            el('img', '', { src: getIconUrl(iconIds[0]), className: 'playerIcon'}),
            names[0]
        ]),
        el('td', [
            el('img', '', { src: getChampionIconUrl(urlNames[0].split(' ').join('')), className: 'playerIcon'}),
            champNames[0]
        ]),
        el('td', ' '),
        el('td', [
            el('img', '', { src: getIconUrl(iconIds[1]), className: 'playerIcon'}),
            names[1]
        ]),
        el('td', [
            el('img', '', { src: getChampionIconUrl(urlNames[1].split(' ').join('')), className: 'playerIcon'}),
            champNames[1]
        ]),
    ]);
    return row;
}