import commonPartials from './partials.js';
import { setHeader } from './auth.js';
import notify from './notification.js';
import { getAll } from '../../models/events.js';

export default function getHome(ctx) {
    setHeader(ctx);
    getAll().
        then(res => {
            const events =  res.docs.map( e => e = {
                ...e.data(),
                id: e.id
            });
            console.log(events);
            ctx.events = events;
            ctx.loadPartials(commonPartials).partial('./view/home.hbs');
        });

    notify('Loading...', '#loadingBox');
}