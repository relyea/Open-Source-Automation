CALL osae_sp_object_type_add ('XBMC','XBMC Plugin','XBMC','PLUGIN',1,0,0,1);
CALL osae_sp_object_type_state_add('ON','Running','XBMC');
CALL osae_sp_object_type_state_add('OFF','Stopped','XBMC');
CALL osae_sp_object_type_event_add('ON','Started','XBMC');
CALL osae_sp_object_type_event_add('OFF','Stopped','XBMC');
CALL osae_sp_object_type_method_add('ON','Start','XBMC','','','','');
CALL osae_sp_object_type_method_add('OFF','Stop','XBMC','','','','');
CALL osae_sp_object_type_property_add('Debug','Boolean','FALSE','XBMC',0);

CALL osae_sp_object_type_add ('XBMC SYSTEM','XBMC System','XBMC','XBMC SYSTEM',0,0,0,1);
CALL osae_sp_object_type_state_add('PLAYING','Playing','XBMC SYSTEM');
CALL osae_sp_object_type_state_add('STOPPED','Stopped','XBMC SYSTEM');
CALL osae_sp_object_type_state_add('PAUSED','Paused','XBMC SYSTEM');
CALL osae_sp_object_type_event_add('PLAYING','Playing','XBMC SYSTEM');
CALL osae_sp_object_type_event_add('STOPPED','Stopped','XBMC SYSTEM');
CALL osae_sp_object_type_event_add('PAUSED','Paused','XBMC SYSTEM');
CALL osae_sp_object_type_method_add('VPLAYPAUSE','Video-Play/Pause','XBMC SYSTEM','','','','');
CALL osae_sp_object_type_method_add('VSTOP','Video-Stop','XBMC SYSTEM','','','','');
CALL osae_sp_object_type_method_add('VBIGSKIPFORWARD','Video-Big Skip Forward','XBMC SYSTEM','','','','');
CALL osae_sp_object_type_method_add('VBIGSKIPBACK','Video-Big Skip Backward','XBMC SYSTEM','','','','');
CALL osae_sp_object_type_property_add('IP','String','','XBMC SYSTEM',0);
CALL osae_sp_object_type_property_add('Port','Integer','','XBMC SYSTEM',0);
CALL osae_sp_object_type_property_add('Username','String','','XBMC SYSTEM',0);
CALL osae_sp_object_type_property_add('Password','String','','XBMC SYSTEM',0);
CALL osae_sp_object_type_property_add('Current Player','String','','XBMC SYSTEM',0);
CALL osae_sp_object_type_property_add('Debug','Boolean','FALSE','XBMC SYSTEM',0);
