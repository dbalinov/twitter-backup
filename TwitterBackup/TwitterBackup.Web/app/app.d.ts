declare module App {
    export interface IScope<TModel> extends ng.IScope {
        model: TModel;
    }

    export interface User {
        Id: string;
        Name: string;
        Description: string;
        IsFavorite: boolean;
        ProfileImageUrl: string;
        Url: string;
        ProfileBackgroundColor: string;
        ProfileBannerUrl: string;
        FollowersCount: number;
        StatusesCount: number;
        FriendsCount: number;
        ScreenName: string;
        Verified: boolean;
    }

    export interface Status {
        Id: string;
    }

    export interface TimelineResponse {
        User?: User;
        Statuses: Status[];
    }

    export interface DashboardResponse {
        DownloadsCount: number;
        RetweetsCount: number;
        RetweetsCountIsAccurate: boolean;
        Users: Array<any>;
    }
}

interface JQuery {
    tooltip: any;
}