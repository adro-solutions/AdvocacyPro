import * as moment from 'moment';
import { ReportPeriod } from 'src/app/enums/reportPeriod.enum';

export class ReportBase {
    dateStart: Date;
    dateEnd: Date;
    preset: ReportPeriod;

    reset() {
        this.dateStart = new Date();
        this.dateEnd = new Date();
        this.preset = ReportPeriod.Custom;
    }

    presetChange() {
        const d = new Date();
        switch (+this.preset) {
            case ReportPeriod.Custom:

                break;
            case ReportPeriod.ThisYear:
                this.dateStart = new Date(d.getFullYear(), 0, 1);
                this.dateEnd = new Date(d.getFullYear(), 11, 31);

                break;
            case ReportPeriod.LastYear:
                this.dateStart = new Date(d.getFullYear() - 1, 0, 1);
                this.dateEnd = new Date(d.getFullYear() - 1, 11, 31);

                break;
            case ReportPeriod.TwoYearsPrior:
                this.dateStart = new Date(d.getFullYear() - 2, 0, 1);
                this.dateEnd = new Date(d.getFullYear() - 2, 11, 31);

                break;
            case ReportPeriod.Today:
                this.dateStart = new Date();
                this.dateEnd = new Date();

                break;
            case ReportPeriod.Yesterday:
                this.dateStart = moment().subtract(1, 'days').toDate();
                this.dateEnd = moment().subtract(1, 'days').toDate();

                break;

        }
    }
}
