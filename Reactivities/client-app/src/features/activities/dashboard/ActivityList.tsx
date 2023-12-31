import { Activity } from '../../../app/models/Activity';
import React from 'react';
import { List, Segment, Item, Button, Label } from "semantic-ui-react";

interface Props{
    activities: Activity[];
    selectActivity: (id: string) => void;
    deleteActivity: (id: string) => void;
}

export default function ActivityList({activities, selectActivity, deleteActivity}: Props){
    return(
        <Segment>
        <Item.Group>
            {activities.map((activity: Activity) => (
                    <Item key={activity.id}>
                        <Item.Content>
                            <Item.Header as='a'>{activity.title}</Item.Header>
                            <Item.Meta>{activity.date}</Item.Meta>
                            <Item.Description>
                                <div>{activity.description}</div>
                                <div>{activity.venue}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button onClick={()=> selectActivity(activity.id)} floated='right' content="view" color='blue' />
                                <Button onClick={()=> deleteActivity(activity.id)} floated='right' content="delete" color='red' />
                                <Label basic content={activity.category}/>
                            </Item.Extra>

                        </Item.Content>
                        
                    </Item>
                ))}
        </Item.Group>
        </Segment>
    )
}