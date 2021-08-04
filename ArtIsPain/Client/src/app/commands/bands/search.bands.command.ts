import { IGetEntitiesCommand } from '../../_interfaces/i-get-entities-command';

export class SearchBandsCommand implements IGetEntitiesCommand {
    searchTerm?: string;
}

