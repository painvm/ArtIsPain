import { BandPreviewModel } from '../band/BandPreviewModel';

export class AlbumViewModel
{
    id: string;
    title: string;
    description: string;
    url: string;
    startRecordDate?: Date;
    releaseDate: Date;
    band: BandPreviewModel;
}
