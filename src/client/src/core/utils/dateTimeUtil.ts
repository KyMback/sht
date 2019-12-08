import moment from "moment";

type DateTime = moment.Moment | Date | undefined;

const dateAndTimeFormat = "YYYY-MM-DD HH:mm:ss";

export function dateAndTime(dateTime: DateTime) {
    return formatDateTime(dateTime, dateAndTimeFormat)
}

function formatDateTime(dateTime: DateTime, format: string): string | undefined {
    if (!dateTime) {
        return undefined;
    }

    return moment(dateTime).format(format);
}
