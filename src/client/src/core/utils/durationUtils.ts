import { Duration } from "moment";
import * as moment from "moment";
import { localStore } from "../../stores/localStore";
import momentDurationFormatSetup from "moment-duration-format";

momentDurationFormatSetup(moment);

export const dateTimeRangeMask = /^(\d+d)?((\s|^)(\d+h))?((\s|^)(\d+m))?$/;
export const zeroDateTimeRangeUnitMask = /^0+[dhm]$/;

export function convertToFormattedDuration(duration?: Duration | string): string | undefined {
    if (!duration) {
        return;
    }

    const convertedDuration = moment.duration(duration);
    const days = convertedDuration.days();
    const hours = convertedDuration.hours();
    const minutes = convertedDuration.minutes();
    const isNegative = days < 0 || hours < 0 || minutes < 0;
    const values = [];

    if (days !== 0) {
        values.push(localStore.getLocalizedMessage("DurationDays_Template", { days: Math.abs(days) }));
    }
    if (hours !== 0) {
        values.push(localStore.getLocalizedMessage("DurationHours_Template", { hours: Math.abs(hours) }));
    }
    if (minutes !== 0) {
        values.push(localStore.getLocalizedMessage("DurationMinutes_Template", { minutes: Math.abs(minutes) }));
    }

    return (isNegative ? "-" : "").concat(values.join(" "));
}

export function convertToTimeSpan(duration?: string): Duration | undefined {
    if (duration == null) {
        return;
    }

    const matches = dateTimeRangeMask.exec(duration);

    if (!matches) {
        return;
    }
    const minutes = matches[3].trim();
    const hours = matches[2].trim();
    const days = matches[1].trim();

    return moment.duration({
        minutes: minutes ? parseInt(minutes) : undefined,
        hours: hours ? parseInt(hours) : undefined,
        days: days ? parseInt(days) : undefined,
    });
}
