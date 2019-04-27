import * as moment from 'moment';
import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class ConvertService {
    defaultDateFormats: string[];

    constructor() {
        this.initDateFormats();
    }

    private initDateFormats(): void {
        let f = 'YYYY-MM-DDTHH:mm:ss';
        this.defaultDateFormats = ['YYYY-MM-DDTHH:mm:ss', 'YYYY-MM-DDTHH:mm:ssZ'];

        f += '.';

        for (let x = 0; x <= 3; x++) {
            f += 'S';
            this.defaultDateFormats.push(f);
            this.defaultDateFormats.push(f + 'Z');
        }
    }

    public isValidDate(value: any, strict?: boolean): boolean {
        let m: moment.Moment;
        let type: string;

        if (strict) {
            m = moment(value, this.defaultDateFormats, true);
        } else {
            m = moment(new Date(value));
        }

        if (!!value && !!value.constructor) {
            type = value.constructor.name;
        } else {
            type = '';
        }

        return ((isNaN(value) || type === 'Date') && m.isValid());
    }

    public UTCtoLocalTime(value: any): Date {
        if (this.isValidDate(value, true)) {
            const m = moment.utc(value, this.defaultDateFormats, true);
            if (m.format('HHmmss') === '000000') {
                return moment(m.format('YYYY-MM-DDT00:00:00')).toDate();
            } else {
                return m.local().toDate();
            }
        }

        return null;
    }

    public localTimeToUTC(value: any): Date {
        if (this.isValidDate(value, false)) {
            const m = moment(value);
            if (m.format('HHmmss') === '000000') {
                return moment(moment(value).format('YYYY-MM-DDT00:00:00-00:00')).utc().toDate();
            } else {
                return m.utc().toDate();
            }
        }

        return null;
    }
}
