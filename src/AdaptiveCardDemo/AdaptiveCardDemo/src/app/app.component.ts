import { Component, AfterViewInit } from '@angular/core';
import * as AdaptiveCards from 'adaptivecards';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    standalone: false,
    styleUrl: './app.component.css'
})
export class AppComponent implements AfterViewInit {

    title = 'Adaptive Card Demo';

    ngAfterViewInit() {
        // Card 1: Static Table
        const tableCard = new AdaptiveCards.AdaptiveCard();
        tableCard.parse({
            type: 'AdaptiveCard',
            version: '1.5',
            body: [
                {
                    type: 'TextBlock',
                    text: 'Work Item Summary',
                    weight: 'Bolder',
                    size: 'Medium'
                },
                {
                    type: 'Table',
                    columns: [
                        {
                            width: 'stretch',
                            items: [
                                {
                                    type: 'TextBlock',
                                    text: 'Type',
                                    weight: 'Bolder'
                                }
                            ]
                        },
                        {
                            width: 'auto',
                            items: [
                                {
                                    type: 'TextBlock',
                                    text: 'Count',
                                    weight: 'Bolder'
                                }
                            ]
                        }
                    ],
                    rows: [
                        {
                            type: 'TableRow',
                            cells: [
                                { type: 'TableCell', items: [{ type: 'TextBlock', text: 'Task' }] },
                                { type: 'TableCell', items: [{ type: 'TextBlock', text: '12' }] }
                            ]
                        },
                        {
                            type: 'TableRow',
                            cells: [
                                { type: 'TableCell', items: [{ type: 'TextBlock', text: 'User Story' }] },
                                { type: 'TableCell', items: [{ type: 'TextBlock', text: '7' }] }
                            ]
                        },
                        {
                            type: 'TableRow',
                            cells: [
                                { type: 'TableCell', items: [{ type: 'TextBlock', text: 'Defect' }] },
                                { type: 'TableCell', items: [{ type: 'TextBlock', text: '4' }] }
                            ]
                        },
                        {
                            type: 'TableRow',
                            cells: [
                                { type: 'TableCell', items: [{ type: 'TextBlock', text: 'Epic' }] },
                                { type: 'TableCell', items: [{ type: 'TextBlock', text: '2' }] }
                            ]
                        }
                    ]
                }
            ]
        });

        // Card 2: Donut Graph (as image)
        const donutCard = new AdaptiveCards.AdaptiveCard();
        donutCard.parse({
            type: 'AdaptiveCard',
            version: '1.5',
            body: [
                {
                    type: 'TextBlock',
                    text: 'Work Item Distribution',
                    weight: 'Bolder',
                    size: 'Medium'
                },
                {
                    type: 'Image',
                    url: 'https://quickchart.io/chart?c=%7B%22type%22%3A%22doughnut%22%2C%22data%22%3A%7B%22labels%22%3A%5B%22Task%22%2C%22User%20Story%22%2C%22Defect%22%2C%22Epic%22%5D%2C%22datasets%22%3A%5B%7B%22data%22%3A%5B12%2C7%2C4%2C2%5D%2C%22backgroundColor%22%3A%5B%22%234e79a7%22%2C%22%23f28e2b%22%2C%22%23e15759%22%2C%22%2376b7b2%22%5D%7D%5D%7D%7D',
                    altText: 'Donut chart showing work item distribution'
                }
            ]
        });

        const container = document.getElementById('adaptiveCardContainer');
        if (container) {
            const renderedTableCard = tableCard.render();
            const renderedDonutCard = donutCard.render();
            if (renderedTableCard) container.appendChild(renderedTableCard);
            if (renderedDonutCard) container.appendChild(renderedDonutCard);
        }
    }
}

